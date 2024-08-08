<template>
  <v-card>
    <v-sheet color="secondary">
      <v-card-title
        >{{ question.text }}
        <v-btn
          class="ml-2"
          variant="tonal"
          icon
          :to="{ name: 'question', params: { id: question.questionId } }"
        >
          <v-icon>fa-solid fa-pencil</v-icon>
        </v-btn>
      </v-card-title>
    </v-sheet>

    <v-card-text>
      <v-chip
        @click="selectAnswer(answer)"
        v-for="answer in question.answers"
        :key="answer.$stableId"
        class="mx-1"
        :color="answerColor(answer)"
      >
        {{ answer.text }}
      </v-chip>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { AnswerViewModel, QuestionViewModel } from "@/viewmodels.g";

const props = defineProps<{
  question: QuestionViewModel;
}>();

const selectedAnswer = ref<AnswerViewModel | null>(null);

function selectAnswer(answer: AnswerViewModel) {
  selectedAnswer.value = answer;
}

function answerColor(answer: AnswerViewModel) {
  if (selectedAnswer.value === null) {
    return "grey";
  }

  if (answer.answerId === props.question.correctAnswer?.answerId) {
    return "success";
  }

  if (selectedAnswer.value.answerId === answer.answerId) {
    return "error";
  }

  return "grey";
}
</script>
